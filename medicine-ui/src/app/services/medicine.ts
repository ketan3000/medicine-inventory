import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Medicine } from '../models/medicine.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MedicineService {
  private apiUrl = `${environment.apiUrl}/medicines`;

  constructor(private http: HttpClient) {}

  getMedicines(searchText: string): Observable<Medicine[]> {
    let params = new HttpParams();

    if (searchText) {
      params = params.set('searchText', searchText);
    }

    return this.http.get<Medicine[]>(this.apiUrl, { params });
  }
}