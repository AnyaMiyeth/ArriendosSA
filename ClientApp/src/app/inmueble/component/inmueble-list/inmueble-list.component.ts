import { Component, OnInit } from '@angular/core';
import { InmuebleService } from '../../../services/inmueble.service';
import { InmuebleViewModel } from '../../viewModel/inmueble-view-model';

@Component({
  selector: 'app-inmueble-list',
  templateUrl: './inmueble-list.component.html',
  styleUrls: ['./inmueble-list.component.css']
})
export class InmuebleListComponent implements OnInit {
  inmuebles: InmuebleViewModel[];
  constructor(private inmuebleService:InmuebleService) { }

  ngOnInit() {
    this.inmuebleService.get().subscribe(result => {
      this.inmuebles = result;

    });

  }
}

