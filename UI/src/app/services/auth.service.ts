import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { AuthResponse } from '../models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userSubject: BehaviorSubject<AuthResponse>;
  public user: Observable<AuthResponse>;

  constructor() {
    this.userSubject = new BehaviorSubject<AuthResponse>(JSON.parse(localStorage.getItem('user')));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): AuthResponse {
    return this.userSubject.value;
  }

  public set userValue(authResponse: AuthResponse) {
    this.userSubject.next(authResponse);
  }
}
