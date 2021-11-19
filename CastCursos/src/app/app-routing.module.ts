import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CursosComponent } from './cursos/cursos.component';
import { PrincipalComponent } from './principal/principal.component';

const routes: Routes = [
  { path: 'Cursos', component: CursosComponent },
  { path: 'Principal', component: PrincipalComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
