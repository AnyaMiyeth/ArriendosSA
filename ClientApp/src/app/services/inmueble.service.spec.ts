import { TestBed } from '@angular/core/testing';

import { InmuebleService } from './inmueble.service';

describe('InmuebleService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: InmuebleService = TestBed.get(InmuebleService);
    expect(service).toBeTruthy();
  });
});
