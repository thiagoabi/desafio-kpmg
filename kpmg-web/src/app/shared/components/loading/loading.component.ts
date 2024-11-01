// loading.component.ts
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadingService } from '@app/services/loading.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-loading',
  template: `
    <div *ngIf="isLoading | async" class="loading-overlay">
      <div class="spinner"></div>
    </div>
  `,
  styleUrls: ['./loading.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class LoadingComponent implements OnInit {
  isLoading!: Observable<boolean>;

  constructor(private loadingService: LoadingService) {}

  ngOnInit(): void {
    this.isLoading = this.loadingService.isLoading$;
  }
}
