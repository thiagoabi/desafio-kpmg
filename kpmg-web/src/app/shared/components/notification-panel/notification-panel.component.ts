// notification-panel.component.ts
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NotificationModel } from '@app/features/notifications/models/notification.model';
import { NotificationService } from '@app/features/notifications/services/notification.service';
import { AccordionButtonDirective, AccordionComponent, AccordionItemComponent, AccordionModule, ModalModule, SharedModule, TemplateIdDirective } from '@coreui/angular';

@Component({
  selector: 'app-notification-panel',
  templateUrl: './notification-panel.component.html',
  standalone: true,
  imports: [
    CommonModule,
    AccordionModule, 
    SharedModule,
    ModalModule, 
    AccordionComponent,
    AccordionItemComponent,
    TemplateIdDirective,
    AccordionButtonDirective]
})
export class NotificationPanelComponent {
  public data: NotificationModel[] = [];
  public isModalOpen = false;

  constructor(private notificationService: NotificationService) {}

  openModal(data: NotificationModel[]) {
    this.data = data; 
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
  }
  
  setNotificationRead(item: any, id: string) {
    this.notificationService.setRead(id);  
    item.toggleItem();
  }

}
