import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'listado-noticias',
    pathMatch: 'full'
  },
    
  { 
    path: 'listado-noticias', 
    loadChildren: './listado-noticias/listado-noticias.module#ListadoNoticiasPageModule'
   },
  { path: 'noticia-detalle/:noticiaID', loadChildren: './noticia-detalle/noticia-detalle.module#NoticiaDetallePageModule' },
  { path: 'agregar', loadChildren: './agregar/agregar.module#AgregarPageModule' },
  { path: 'autor', loadChildren: './autor/autor.module#AutorPageModule' },
  { path: 'lista-autor', loadChildren: './lista-autor/lista-autor.module#ListaAutorPageModule' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
