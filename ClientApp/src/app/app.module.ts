import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';


import { AlertModalComponent } from './@base/modals/alert-modal/alert-modal.component';
import { CreditoRegisterComponent } from './creditos/credito-register/credito-register.component';
import { ClienteConsultaComponent } from './clientes/consulta/cliente-consulta.component';
import { ClienteConsultaModalComponent } from './clientes/modals/cliente-consulta-modal/cliente-consulta-modal.component';
import { UploadComponent } from './upload/upload.component';
import { ViewDocumentComponent } from './view-document/view-document.component';
import { FiltroClientePipe } from './pipes/filtro-cliente.pipe';
import { AuthGuard } from './guards/auth-guard';

import { InmuebleAddComponent } from './inmueble/component/inmueble-add/inmueble-add.component';
import { InmuebleListComponent } from './inmueble/component/inmueble-list/inmueble-list.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AlertModalComponent,
    CreditoRegisterComponent,
    ClienteConsultaComponent,
    ClienteConsultaModalComponent,
    UploadComponent,
    ViewDocumentComponent,
    FiltroClientePipe,
  
    InmuebleAddComponent,
    InmuebleListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'credito-register', component: CreditoRegisterComponent },
      { path: 'clientes-consulta', component: ClienteConsultaComponent },
      { path:'inmueble-list',component:InmuebleListComponent},
      { path: 'inmueble-add', component: InmuebleAddComponent },
       
    ]),
      NgbModule,
      ReactiveFormsModule
  ],
    bootstrap: [AppComponent],
    entryComponents: [
        AlertModalComponent,
        ClienteConsultaComponent,
        ClienteConsultaModalComponent
    ]
})
export class AppModule { }



