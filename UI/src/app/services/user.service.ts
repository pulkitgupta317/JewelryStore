import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthRequest, AuthResponse } from '../models';
import { map } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl: string;

  constructor(private httpClient: HttpClient,
    private authService: AuthService) {
    this.baseUrl = `${environment.appUrl}/api/user`;
  }

  authenticateUser(request: AuthRequest): Observable<AuthResponse> {
    return this.httpClient.post<AuthResponse>(`${this.baseUrl}/authenticate`, request)
      .pipe(map(user => {
        localStorage.setItem('user', JSON.stringify(user));
        this.authService.userValue = user;
        return user;
      }));
  }
}
