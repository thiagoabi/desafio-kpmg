import { Component, OnInit, ViewChild } from '@angular/core';
import { IncidentRequest, IncidentResponse } from '../../models/incident.model';
import { IncidentService } from '../../services/incident.service';
import { SharedModule } from '@shared/modules/shared.module';
import { ButtonGroupModule, TableModule, UtilitiesModule } from '@coreui/angular';
import { TextResources } from '@resources'
import { IncidentCreateComponent } from "../incident-create/incident-create.component";
import { IncidentDetailComponent } from "../incident-detail/incident-detail.component";
import { IncidentUpdateComponent } from "../incident-update/incident-update.component";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-incident-list',
  templateUrl: './incident-list.component.html',
  styleUrls: ['./incident-list.component.css'],
  standalone: true,
  imports: [SharedModule, TableModule, ButtonGroupModule, UtilitiesModule, IncidentCreateComponent, IncidentDetailComponent, IncidentUpdateComponent]
})
export class IncidentListComponent implements OnInit {
  @ViewChild(IncidentCreateComponent) incidentCreateComponent!: IncidentCreateComponent;
  @ViewChild(IncidentUpdateComponent) incidentUpdateComponent!: IncidentUpdateComponent;

  TextResources = TextResources;

  public visibleCreateModal = false;
  public visibleDetailModal = false;
  public visibleUpdateModal = false;

  data: IncidentResponse[] = [];

  selectedData?: IncidentResponse;

  constructor(private incidentService: IncidentService) { }

  ngOnInit(): void {
    this.loadIncidents();
  }

  loadIncidents(): void {
    this.incidentService.getAll().subscribe(response => {
      this.data = response;
    });
  }

  openCreateModal() {
    this.visibleCreateModal = true;
  }

  openDetailModal(item: IncidentResponse) {
    this.selectedData = item;
    this.visibleDetailModal = true;
  }

  openEditModal(item: IncidentResponse) {
    this.selectedData = item;
    this.visibleUpdateModal = true;
  }

  delete(id: string) {
    this.visibleDetailModal = true;
  }  

  toggleCreateModal() {
    this.visibleCreateModal = !this.visibleCreateModal;
  }

  toggleDetailModal() {
    this.visibleDetailModal = !this.visibleDetailModal;
  }

  toggleUpdateModal() {
    this.visibleUpdateModal = !this.visibleUpdateModal;
  }

  handleModalCreateClose(event: any) {
    this.visibleCreateModal = event;
  }

  handleModalDetailClose(event: any) {
    this.visibleDetailModal = event;
  }

  handleModalUpdateClose(event: any) {
    this.visibleUpdateModal = event;
  }

  onCreate() {
    this.incidentCreateComponent.Save();
  }

  onUpdate() {
    this.incidentUpdateComponent.Save();
    this.toggleUpdateModal();
  }

  onDelete(id: string) {Swal.fire({
    title: "Deseja realmente excluir o registro de Incidente?",
    showCancelButton: true,
    confirmButtonText: "Confirmar",
    cancelButtonText: "Cancelar",
    confirmButtonColor: "#d33",
    cancelButtonColor: "#3085d6",
  }).then((result) => {
    if (result.isConfirmed) {
      this.incidentService.delete(id)
      .subscribe(response => {
        this.loadIncidents();
      });
    }
  });
  }
  afterSave() {
    this.loadIncidents();
  }
} 
