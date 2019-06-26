import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Noticia } from 'src/app/models/noticia.models';
import { Autor } from 'src/app/models/autor.models';

@Injectable({
  providedIn: 'root'
})
export class NoticiasService {

  constructor(public https: HttpClient) { }


  verNoticias() : Observable<Noticia[]> {
    return this.https.get<Noticia[]>("https://localhost:5001/api/noticias/vernoticias");
  }

  porNoticiaID(noticiaID: number) : Observable<Noticia>{
    return this.https.get<Noticia>("https://localhost:5001/api/noticias/PorNoticiaID/" + noticiaID)
  }


  eliminarNoticia(noticiaID: number): Observable<boolean>
  {
    return this.https.get<boolean>("https://localhost:5001/api/noticias/eliminar/" + noticiaID)
  }


  listadoDeAutores(): Observable<Autor[]>
  {
    return this.https.get<Autor[]>("https://localhost:5001/api/noticias/listadoAutores/")
  }


  agregarNoticia(noticia: Noticia): Observable<boolean>
  {
    return this.https.post<boolean>("https://localhost:5001/api/noticias/agregar",noticia)
  }


  editarNoticia(noticia: Noticia): Observable<boolean>
  {
    return this.https.put<boolean>("https://localhost:5001/api/noticias/Editar",noticia)
  }
}
