// notification.service.ts
import { Injectable } from '@angular/core';
import { NotificationPanelComponent } from '../shared/components/notification-panel/notification-panel.component'

@Injectable({
  providedIn: 'root'
})
export class NotificationPanelService {
  private notificationPanel!: NotificationPanelComponent;

  registerNotificationPanel(panel: NotificationPanelComponent) {
    this.notificationPanel = panel;
  }

  showNotification(message: string) {
    if (this.notificationPanel) {
      this.notificationPanel.addNotification(message);
    }
  }

  clearNotifications() {
    if (this.notificationPanel) {
      this.notificationPanel.clearNotifications();
    }
  }
}
