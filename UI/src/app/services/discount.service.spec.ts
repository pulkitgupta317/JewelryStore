import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';

import { DiscountService } from './discount.service';

describe('DiscountService', () => {
  let service: DiscountService;

  const httpClientServiceStub = {
    get(url: string): Observable<number> {
      return of(2);
    }
  }

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: HttpClient,
          useValue: httpClientServiceStub
        }
      ]
    });
    service = TestBed.inject(DiscountService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should be discount not null', () => {
    let result: number;
    service.getDiscount().subscribe(x => {
      result = x;
    });
    expect(result).toBeTruthy();
  });
});
