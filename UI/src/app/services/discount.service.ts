import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DiscountService {

  baseUrl: string;

  constructor(private httpClient: HttpClient) {
    this.baseUrl = `${environment.appUrl}/api/discount`;
  }

  getDiscount(): Observable<number> {
    return this.httpClient.get<number>(`${this.baseUrl}/GetDiscount`);
  }
}
