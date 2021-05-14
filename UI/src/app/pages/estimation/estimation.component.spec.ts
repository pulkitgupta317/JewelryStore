import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { AuthResponse } from 'src/app/models';
import { AuthService, DiscountService } from 'src/app/services';

import { EstimationComponent } from './estimation.component';

describe('EstimationComponent', () => {
  let component: EstimationComponent;
  let fixture: ComponentFixture<EstimationComponent>;

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

  const discountServiceStub: Partial<DiscountService> = {
    getDiscount(): Observable<number> {
      return of(2);
    }
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EstimationComponent],
      providers: [
        FormBuilder,
        {
          provide: AuthService,
          useValue: authServiceStub
        },
        {
          provide: DiscountService,
          useValue: discountServiceStub
        }
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstimationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get controls', () => {
    expect(component.f).toBeTruthy();
  });

  it('should print on screen', () => {
    spyOn(window, 'alert');
    component.printToScreen();
    expect(window.alert).toHaveBeenCalledWith('Total amount is: 0');
  });

  // it('should throw error on print to paper', () => {
  //   expect(component.printToPaper).toThrowError('Not implemented');
  // });

  it('should not print on screen', () => {
    component.estimationForm.patchValue({
      GoldPrice: -1
    });
    component.printToScreen();
  });

  it('should not print on paper', () => {
    component.estimationForm.patchValue({
      GoldPrice: -1
    });
    component.printToPaper();
  });

  it('should success on submit', () => {
    component.estimationForm.patchValue({
      GoldPrice: 1,
      Weight: 2
    });
    component.onSubmit();
    expect(component.totalAmount).toEqual(1.96);
  });

  it('should success on print to file', () => {
    component.estimationForm.patchValue({
      GoldPrice: 1,
      Weight: 2
    });
    component.printToFile();
  });

  it('should success on print to file when discount not visible', () => {
    component.estimationForm.patchValue({
      GoldPrice: 1,
      Weight: 2
    });
    component.isDiscountVisible = true;
    component.printToFile();
  });
});
