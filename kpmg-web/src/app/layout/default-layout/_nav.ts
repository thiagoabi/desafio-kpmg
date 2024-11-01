import { INavData } from '@coreui/angular';
import { TextResources } from '@resources';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' }
  },
  {
    name: TextResources.Incidents.Menu.Title,
    title: true
  },
  {
    name: TextResources.Incidents.Menu.List,
    url: '/incidents'
  },
  {
    name: TextResources.Incidents.Menu.Create,
    url: '/incident/create'
  },
  {
    name: 'Compliance e Conformidade',
    title: true
  },
  {
    name: 'Listar Checklists de Conformidade',
    url: '/compliance-check/list'
  },
  {
    name: 'Adicionar Checklists de Conformidade',
    url: '/compliance-check/create'
  },
  {
    name: TextResources.RiskAssessments.Menu.Title,
    title: true
  },
  {
    name: TextResources.RiskAssessments.Menu.List,
    url: '/riskassessments'
  },
  {
    title: true,
    name: 'Links',
    class: 'mt-auto'
  },
  {
    name: 'GitHub',
    url: 'https://github.com/thiagoabi/desafio-kpmg',
    attributes: { target: '_blank' }
  }
];
