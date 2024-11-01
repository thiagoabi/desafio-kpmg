import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IncidentService } from '../../services/incident.service';
import { UserService } from '@app/services/user.services';
import { SharedModule } from '@shared/modules/shared.module';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EnumIncidentType, EnumIncidentTypeLabelMapping, EnumSeverityLevel, EnumSeverityLevelLabelMapping } from '@shared/enumerators/enumerators';
import { IncidentRequest } from '../../models/incident.model';
import { UserModel } from '@app/shared/models/user.model';

@Component({
    selector: 'app-incident-create',
    templateUrl: './incident-create.component.html',
    styleUrls: ['./incident-create.component.css'],
    standalone: true,
    imports: [SharedModule]
})
export class IncidentCreateComponent implements OnInit {
  @Output() saveClicked = new EventEmitter<void>();

  form: FormGroup;

  EnumIncidentType = EnumIncidentType;
  EnumIncidentTypeLabelMapping = EnumIncidentTypeLabelMapping;
  
  EnumSeverityLevel = EnumSeverityLevel;
  EnumSeverityLevelLabelMapping = EnumSeverityLevelLabelMapping;

  severityLevels = EnumSeverityLevel;

  users: UserModel[] = [];

  constructor(
    private route: ActivatedRoute, 
    private incidentService: IncidentService, 
    private userService: UserService, 
    private fb: FormBuilder) {
    this.form = this.fb.group({
      userId: ['', Validators.required],
      incidentType: [null, Validators.required],
      severityLevel: [null, Validators.required],
      description: ['', Validators.required],
      incidentDate: [null, Validators.required],
    });
  } 

  ngOnInit(): void {
      this.loadUsers();
  }
  
  loadUsers() {
    this.userService.getAll()
    .subscribe(response => 
      {
        this.users = response; 
      });
  }

  public Save() {
    if (this.form.valid) {
      const incidentData: IncidentRequest = this.form.value;
  
      this.incidentService.create(incidentData).subscribe(
        () => {
          this.saveClicked.emit();
          this.form.reset(); 
        },
        error => {
          console.error('Erro ao criar incidente:', error);
        }
      );
    } else {
      console.warn('Formulário inválido');
    }
  }
}
