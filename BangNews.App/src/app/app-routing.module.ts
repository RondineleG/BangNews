import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'listado-noticias',
    pathMatch: 'full'
  },
  {
    path: 'home',
    loadChildren: () => import('../app/home/home.module').then(x => x.HomePageModule)

  },
  {
    path: 'list',
    loadChildren: () => import('../app/list/list.module').then(x => x.ListPageModule)
  },
  { 
    path: 'listado-noticias', 
    loadChildren: () => import('../app/listado-noticias/listado-noticias.module').then(x => x.ListadoNoticiasPageModule)
   },
  { 
    path: 'noticia-detalle/:noticiaID',
     loadChildren: () => import('../app/noticia-detalle/noticia-detalle.module').then(x => x.NoticiaDetallePageModule)
  },
  { 
    path: 'agregar',
     loadChildren: () => import('../app/agregar/agregar.module').then(x => x.AgregarPageModule)
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
