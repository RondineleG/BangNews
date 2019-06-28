import { Component } from '@angular/core';

import { Platform } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
  public appPages = [
    {
      titulo: 'Noticias',
      url: '/listado-noticias',
      icon: 'book'
    },
    
   
    {
      titulo:'Nova Noticia',
      url: '/agregar',
      icon: 'add'
    },
    {
      titulo: 'Autor',
      url: '/lista-autor',
      icon: 'book'
    },
    
    {
      titulo:'Novo Autor',
      url: '/agregar',
      icon: 'add'
    }
  ];

  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar
  ) {
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });
  }
}
