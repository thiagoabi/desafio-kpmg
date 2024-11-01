using KPMG.ComplianceMonitor.Domain.Core.Entities;
using KPMG.ComplianceMonitor.Domain.Core.Interfaces;

namespace KPMG.ComplianceMonitor.Domain.Entities;

public class ComplianceChecklist : Entity, IEntity, IAggregateRoot
{
    public ComplianceChecklist(Guid id, Guid complianceCheckId,
        string checklistItem, bool isCompliant, string? comments = null)
        : base(id)
    {
        ComplianceCheckId = complianceCheckId;
        ChecklistItem = checklistItem;
        IsCompliant = isCompliant;
        Comments = comments;
    }

    protected ComplianceChecklist() { }

    public Guid? ComplianceCheckId { get; private set; } 
    public string? ChecklistItem { get; private set; }
    public bool IsCompliant { get; private set; }
    public string? Comments { get; private set; }


    public virtual ComplianceCheck? ComplianceCheck { get; private set; }
}
