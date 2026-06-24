import { Component } from '@angular/core';
import { MedicinesComponent } from './medicines/medicines';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [MedicinesComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}