import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Avaliações de Risco'
    },
    children: [
      {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full'
      },
      {
        path: 'list',
        loadComponent: () => import('./pages/risk-assessment-list-page/risk-assessment-list-page.component').then(m => m.RiskAssessmentListPageComponent),
        data: {
          title: 'Listagem'
        }
      },
      {
        path: 'detail',
        loadComponent: () => import('./pages/risk-assessment-detail-page/risk-assessment-detail-page.component').then(m => m.RiskAssessmentDetailPageComponent),
        data: {
          title: 'Detalhes'
        }
      },
      {
        path: 'create',
        loadComponent: () => import('./pages/risk-assessment-create-page/risk-assessment-create-page.component').then(m => m.RiskAssessmentCreatePageComponent),
        data: {
          title: 'Criar ou Editar'
        }
      },
    ]
  }
];
