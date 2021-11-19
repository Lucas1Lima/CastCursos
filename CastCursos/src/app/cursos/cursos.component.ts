import { UsuariosService } from './../shared/usuarios.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Cursos } from '../shared/cursos';
import { CursosService } from '../shared/cursos.service';
import { CategoriaService } from '../shared/categoria.service';
import { HttpClient } from '@angular/common/http';
import { LogService } from '../shared/log.service';

@Component({
  selector: 'app-cursos',
  templateUrl: './cursos.component.html',
  providers: [],
})
export class CursosComponent implements OnInit {
  public resultadosDescricao: any = [];
  private _filtroLista: string = '';
  public categorias: any[];
  public usuarios: any[];
  public erroData: boolean = false;

  constructor(
    public curso: CursosService,
    private toastr: ToastrService,
    public categoria: CategoriaService,
    private http: HttpClient,
    public usuario: UsuariosService,
    public log: LogService
  ) {}

  verificarData(dataInicio: Date, dataFinal: Date) {
    if (dataInicio && dataFinal) {
      var dtInicio = new Date(dataInicio);
      var dtFinal = new Date(dataFinal);
      if (dtFinal < dtInicio) {
        this.erroData = true;
      } else {
        this.erroData = false;
      }
    } else {
      this.erroData = false;
    }
  }

  public get filtro(): string {
    return this._filtroLista;
  }

  public set filtro(value: string) {
    this._filtroLista = value;
    this.resultadosDescricao = this.filtro
      ? this.filtrar(this.filtro)
      : this.curso.list;
  }

  filtrar(filtrarPelo: string): any {
    filtrarPelo = filtrarPelo.toLocaleLowerCase().trim();
    return this.curso.list.filter(
      (resultado: { descricao: string; dataInicio: Date; dataFinal: Date}) =>
        resultado.descricao.toLocaleLowerCase().indexOf(filtrarPelo) !== -1 ||
        resultado.dataInicio.toString().toLocaleLowerCase().indexOf(filtrarPelo) !== -1 ||
        resultado.dataFinal.toString().toLocaleLowerCase().indexOf(filtrarPelo) !== -1
    );
  }


  ngOnInit() {
    this.darRefreshList();
    this.curso.refreshList();
    this.categoria.getCategorias().subscribe(
      (res) => {
        this.categoria.lista = res;
        this.categorias = this.categoria.lista;
      },
      (err) => {
        console.log(err);
      }
    );
    this.usuario.getUsuarios().subscribe(
      (res) => {
        this.usuario.listas = res;
        this.usuarios = this.categoria.lista;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  populateForm(selectedRecord: Cursos) {
    this.curso.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Deseja apagar?')) {
      this.curso.deleteCursos(id).subscribe(
        (res) => {
          this.darRefreshList();
          this.toastr.warning('Apagado com Sucesso', 'Deleted successfully');
        },
        (err) => {
          console.log(err.status);
          this.toastr.error("Este curso já foi finalizado");
        }
      );
      this.log.postLogs();
    }
  }

  darRefreshList() {
    this.http
      .get(this.curso.baseURL)
      .toPromise()
      .then((response) => {
        this.resultadosDescricao = response as Cursos[];
      });
  }

  aoEnviar(form: NgForm) {
    if (this.curso.formData.id == 0) this.darPost(form);
    else this.darUpdate(form);
  }

  darPost(form: NgForm) {
    this.curso.postCursos().subscribe(
      (res) => {
        this.darResetForm(form);
        this.darRefreshList();
        this.toastr.success(
          'Submitted successfully','Adicionado com Sucesso'
        );
      },
      (erro) => {
        console.log(erro);
        if(erro.status == 400){
          this.toastr.warning("Esta descrição já foi cadastrada.");
        }
        if(erro.status == 404){
          this.toastr.warning("Existe(m) curso(s) planejados(s) dentro do período informado.");
        }
        if(erro.status == 401){
          this.toastr.warning("Não é possível adicionar um curso antes que a data atual.");
        }
      }

    );
  }

  darUpdate(form: NgForm) {
    this.curso.putCursos().subscribe(
      (res) => {
        this.darResetForm(form);
        this.darRefreshList();
        this.toastr.info('Atualizado com Sucesso', 'Updated Successfully');
      },
      (err) => {
        console.log(err);
        if(err.status == 404){
          this.toastr.warning("Descrição está vazia");
        }
        if(err.status == 400){
          this.toastr.warning("Verifique o campo 'Quantidade de Alunos'");
        }
      }
    );
    this.log.postLogs();
  }

  darResetForm(form: NgForm) {
    form.form.reset();
    this.curso.formData = new Cursos();
  }
}
