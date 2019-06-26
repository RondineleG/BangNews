import { Component, OnInit } from '@angular/core';
import { NoticiasService } from '../services/noticias-service/noticias.service';
import { Autor } from '../models/autor.models';
import { Noticia } from '../models/noticia.models';
import { LoadingController, ToastController } from '@ionic/angular';
import {  ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-agregar',
  templateUrl: './agregar.page.html',
  styleUrls: ['./agregar.page.scss'],
})
export class AgregarPage implements OnInit {
  autores: Autor[] = new Array<Autor>();
  noticia: Noticia = new Noticia();


  esEditable: boolean = false;
  constructor(private noticiaServicio: NoticiasService, public loadingController: LoadingController, 
    public toastController: ToastController, private activatedRoute : ActivatedRoute) { }

  ngOnInit() {

  
    if(this.activatedRoute.snapshot.params.noticiaEditar != undefined)
    {
      this.noticia = new Noticia(JSON.parse(this.activatedRoute.snapshot.params.noticiaEditar));
      this.esEditable = true
    }

  
    this.noticiaServicio.listadoDeAutores().subscribe((listadoAutores)=>{
      this.autores = listadoAutores
    })
  }


  async guardar()
  {
    const loading = await this.loadingController.create({
      message: 'Salvando Noticia',
    });
    await loading.present();

    
    this.noticiaServicio.agregarNoticia(this.noticia).subscribe(()=>{
      this.noticia = new Noticia(null)
      loading.dismiss();
      this.mostrarMensaje("Noticia Salva Com Sucesso!")
     
    },
    error=>{
      this.mostrarMensaje("Error Ao Salvar Noticia @??@")
      loading.dismiss();
    })
  }


  async editar()
  {
    const loading = await this.loadingController.create({
      message: 'Editando Noticia',
    });
    await loading.present();

    
    this.noticiaServicio.editarNoticia(this.noticia).subscribe(()=>{
      
      loading.dismiss();
      this.mostrarMensaje("Noticia Editada Com Sucesso!")
     
    },
    error=>{
      this.mostrarMensaje("Error Ao Salvar Noticia @??@")
      loading.dismiss();
    })
  }



  async mostrarMensaje(mensaje: string){
    const toast = await this.toastController.create({
      message: mensaje,
      duration: 2000
    });
    toast.present();
  }

}
