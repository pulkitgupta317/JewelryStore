import { TestBed } from '@angular/core/testing';
import { AuthResponse } from '../models';
import { AuthService } from '../services';

import { JwtInterceptor } from './jwt.interceptor';

describe('JwtInterceptor', () => {

  const authServiceStub: Partial<AuthService> = {
    get userValue(): AuthResponse {
      return {
        AccessToken: 'testing',
        ExpireIn: 12,
        UserName: 'Something',
        UserRole: 'Something'
      };
    }
  }

  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      JwtInterceptor,
      {
        provide: AuthService,
        useValue: authServiceStub
      }
    ]
  }));

  it('should be created', () => {
    const interceptor: JwtInterceptor = TestBed.inject(JwtInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
