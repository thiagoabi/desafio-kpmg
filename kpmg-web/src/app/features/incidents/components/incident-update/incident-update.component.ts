import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IncidentService } from '../../services/incident.service';
import { UserService } from '@app/services/user.services';
import { SharedModule } from '@shared/modules/shared.module';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IncidentRequest, IncidentResponse } from '../../models/incident.model';

@Component({
    selector: 'app-incident-update',
    templateUrl: './incident-update.component.html',
    styleUrls: ['./incident-update.component.css'],
    standalone: true,
    imports: [SharedModule]
})
export class IncidentUpdateComponent {
  @Input() incident?: IncidentResponse;
  @Output() saveClicked = new EventEmitter<void>();

  form: FormGroup;

  constructor(
    private route: ActivatedRoute, 
    private incidentService: IncidentService, 
    private fb: FormBuilder) {
    this.form = this.fb.group({
      isResolved: [true, Validators.required],
      resolutionDate: [null, Validators.required],
      resolutionDetails: [null, Validators.required]
    });
  } 

  public Save() {
    if (this.form.valid) {
      const incidentData: IncidentRequest = this.form.value;
  
      this.incidentService.update(this.incident!.id, incidentData).subscribe(
        () => {
          this.saveClicked.emit();
          this.form.reset(); 
        },
        error => { 
          console.error('Erro ao atualizar incidente:', error);
        }
      );
    } else {
      console.warn('Formulário inválido');
    }
  }
}
