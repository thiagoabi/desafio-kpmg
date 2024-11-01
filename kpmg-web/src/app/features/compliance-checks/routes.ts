import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Compliance e Conformidade'
    },
    children: [
      {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full'
      },
      {
        path: 'list',
        loadComponent: () => import('./pages/compliance-check-list-page/compliance-check-list-page.component').then(m => m.ComplianceCheckListPageComponent),
      },
      {
        path: 'detail',
        loadComponent: () => import('./pages/compliance-check-detail-page/compliance-check-detail-page.component').then(m => m.ComplianceCheckDetailPageComponent),
        data: {
          title: 'Detalhes'
        }
      },
      {
        path: 'create',
        loadComponent: () => import('./pages/compliance-check-create-page/compliance-check-create-page.component').then(m => m.ComplianceCheckCreatePageComponent),
        data: {
          title: 'Criar ou Editar'
        }
      },
    ]
  }
];
