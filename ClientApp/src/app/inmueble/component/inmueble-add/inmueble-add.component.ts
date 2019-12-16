import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InmuebleService } from '../../../services/inmueble.service';
import { InmuebleViewModel } from '../../viewModel/inmueble-view-model';
import { AlertModalComponent } from '../../../@base/modals/alert-modal/alert-modal.component';

@Component({
  selector: 'app-inmueble-add',
  templateUrl: './inmueble-add.component.html',
  styleUrls: ['./inmueble-add.component.css']
})
export class InmuebleAddComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private servicoInmueble: InmuebleService,
    private modalService: NgbModal) { }

  inmueble: InmuebleViewModel;
  formRegister: FormGroup;
  submitted = false;
  ngOnInit() {


    this.inmueble = new InmuebleViewModel();

    this.formRegister = this.formBuilder.group({
      numeroMatricula: [this.inmueble.numeroMatricula, Validators.required],
      direccion: [this.inmueble.direccion, Validators.required],
      descripcion: [this.inmueble.descripcion, Validators.required],
      departamento: [this.inmueble.departamento, Validators.required],
      ciudad: [this.inmueble.ciudad, Validators.required],
      valor: [this.inmueble.valor, Validators.required]
    });
  }


  get f() { return this.formRegister.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.formRegister.invalid) {
      return;
    }
    this.create();
  }


  create() {
    this.inmueble = this.formRegister.value;
    this.servicoInmueble.post(this.inmueble).subscribe(r => {
      if (r != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = 'Resultado Operación';
        messageBox.componentInstance.message = 'La operacion se realizo Satisfactoriamente';
      }

    });
  }

  onReset() {
    this.submitted = false;
    this.formRegister.reset();
  }

}
