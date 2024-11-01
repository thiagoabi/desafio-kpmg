﻿using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Infra.Data.Context;
using KPMG.ComplianceMonitor.Infra.Data.Repositories.Base;

namespace KPMG.ComplianceMonitor.Infra.Data.Repositories;

public class ComplianceChecklistRepository(ComplianceMonitorContext context)
    : Repository<ComplianceChecklist>(context, "Conformidade"), IRepository<ComplianceChecklist>, IComplianceChecklistRepository
{ }
