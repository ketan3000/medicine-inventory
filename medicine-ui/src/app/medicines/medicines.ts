import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


import { Medicine } from '../models/medicine.model';
import { MedicineService } from '../services/medicine';

@Component({
  selector: 'app-medicines',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './medicines.html',
  styleUrls: ['./medicines.css']
})
export class MedicinesComponent implements OnInit {
  medicines: Medicine[] = [];
  searchText: string = '';

  constructor(private medicineService: MedicineService) {}

  ngOnInit(): void {
    this.loadMedicines();
  }

  loadMedicines(): void {
    this.medicineService.getMedicines(this.searchText)
      .subscribe({
        next: (data) => {
          this.medicines = data;
        },
        error: (error) => {
          console.error('Error while loading medicines', error);
        }
      });
  }

  search(): void {
    this.loadMedicines();
  }

  clear(): void {
    this.searchText = '';
    this.loadMedicines();
  }

  getRowClass(rowColor: string): string {
    if (rowColor === 'red') {
      return 'red-row';
    }

    if (rowColor === 'yellow') {
      return 'yellow-row';
    }

    return '';
  }
}