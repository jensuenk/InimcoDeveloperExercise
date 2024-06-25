import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserInputComponent } from './modules/user-input/user-input.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, UserInputComponent],
  template: `<app-user-input></app-user-input>`,
  styleUrls: ['./app.component.scss']
})
export class AppComponent {}