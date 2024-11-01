import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Gerenciamento de Incidentes'
    },
    children: [
      {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full'
      },
      {
        path: 'list',
        loadComponent: () => import('./pages/incident-list-page/incident-list-page.component').then(m => m.IncidentListPageComponent)
      },
      {
        path: 'detail',
        loadComponent: () => import('./pages/incident-detail-page/incident-detail-page.component').then(m => m.IncidentDetailPageComponent),
        data: {
          title: 'Detalhes'
        }
      },
      {
        path: 'create',
        loadComponent: () => import('./pages/incident-create-page/incident-create-page.component').then(m => m.IncidentCreatePageComponent),
        data: {
          title: 'Criar ou Editar'
        }
      },
    ]
  }
];
