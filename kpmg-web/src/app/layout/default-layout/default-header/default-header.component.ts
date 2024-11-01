import { CommonModule, NgStyle, NgTemplateOutlet } from '@angular/common';
import { Component, computed, inject, input, OnDestroy, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

import {
  AvatarComponent,
  AvatarModule,
  BadgeComponent,
  BadgeModule,
  BreadcrumbRouterComponent,
  ColorModeService,
  ContainerComponent,
  DropdownComponent,
  DropdownDividerDirective,
  DropdownHeaderDirective,
  DropdownItemDirective,
  DropdownMenuDirective,
  DropdownModule,
  DropdownToggleDirective,
  GridModule,
  HeaderComponent,
  HeaderNavComponent,
  HeaderTogglerDirective,
  ModalModule,
  NavItemComponent,
  NavLinkDirective,
  ProgressBarDirective,
  ProgressComponent,
  SidebarModule,
  SidebarToggleDirective,
  TextColorDirective,
  ThemeDirective
} from '@coreui/angular';

import { IconDirective } from '@coreui/icons-angular';

import { NotificationService } from '@app/features/notifications/services/notification.service';
import { Subscription } from 'rxjs';
import { AppComponent } from '@app/app.component';
import { NotificationModel } from '@app/features/notifications/models/notification.model';

@Component({
  selector: 'app-default-header',
  templateUrl: './default-header.component.html',
  standalone: true,
  imports: [ModalModule, BadgeModule, CommonModule, AvatarModule, SidebarModule, GridModule, DropdownModule, ContainerComponent, HeaderTogglerDirective, SidebarToggleDirective, IconDirective, HeaderNavComponent, NavItemComponent, NavLinkDirective, RouterLink, RouterLinkActive, NgTemplateOutlet, BreadcrumbRouterComponent, ThemeDirective, DropdownComponent, DropdownToggleDirective, TextColorDirective, AvatarComponent, DropdownMenuDirective, DropdownHeaderDirective, DropdownItemDirective, BadgeComponent, DropdownDividerDirective, ProgressBarDirective, ProgressComponent, NgStyle]
})
export class DefaultHeaderComponent extends HeaderComponent  implements OnInit, OnDestroy {

  notificationCount: number = 0;
  visibleNotifModal: boolean = false;

  private notificationSubscription: Subscription | undefined;

  readonly #colorModeService = inject(ColorModeService);
  readonly colorMode = this.#colorModeService.colorMode;

  notifications: NotificationModel[] = [];

  readonly colorModes = [
    { name: 'light', text: 'Light', icon: 'cilSun' },
    { name: 'dark', text: 'Dark', icon: 'cilMoon' },
    { name: 'auto', text: 'Auto', icon: 'cilContrast' }
  ];

  readonly icons = computed(() => {
    const currentMode = this.colorMode();
    return this.colorModes.find(mode => mode.name === currentMode)?.icon ?? 'cilSun';
  });

  constructor(private appComponent: AppComponent, private notificationService: NotificationService) {
    super();
  }
  
  sidebarId = input('sidebar1');

  ngOnInit(): void {
    this.subscribeToNotifications();
  }
  
  showNotifications() {
    this.appComponent.openNotificationPanel(this.notifications);
  }

  subscribeToNotifications(): void {
    this.notificationSubscription = this.notificationService.getNotifications('9fefcc98-d7bc-4c81-918d-43eb6e3dd1c3').subscribe({
      next: (response) => {
        this.notifications = response;
        this.notificationCount = response.length;
      },
      error: (error) => {
      }
    });
  }

  getNotificationsCount() {
    return this.notificationCount < 100 ? this.notificationCount : `99+`;
  }

  getStatus() {
    return this.notificationCount > 0 ? 'warning' : 'success';
  }

  ngOnDestroy(): void {
    // Fechar a assinatura do Observable para evitar vazamentos de memória
    if (this.notificationSubscription) {
      this.notificationSubscription.unsubscribe();
    }
  }
}
