import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import jsPDF from 'jspdf';
import { AuthService, DiscountService } from 'src/app/services';

@Component({
  selector: 'app-estimation',
  templateUrl: './estimation.component.html',
  styleUrls: ['./estimation.component.css']
})
export class EstimationComponent implements OnInit {

  estimationForm: FormGroup;
  submitted: boolean;
  isDiscountVisible = false;
  totalAmount: number = 0;

  constructor(private formBuilder: FormBuilder,
    private discountService: DiscountService,
    public authService: AuthService) { }

  ngOnInit(): void {
    this.isDiscountVisible = this.authService.userValue.UserRole === 'Privileged';
    this.estimationForm = this.formBuilder.group({
      GoldPrice: [0, [
        Validators.required,
        Validators.min(0)]
      ],
      Weight: [0, [
        Validators.required,
        Validators.min(0)]
      ],
      Discount: [0, [
        Validators.required,
        Validators.min(0),
        Validators.max(100)]
      ]
    });
    this.discountService.getDiscount().subscribe(x => {
      this.estimationForm.patchValue({
        Discount: x
      });
    }, error => {
      console.log(error);
    });
  }

  get f() {
    return this.estimationForm.controls;
  }

  onSubmit() {
    this.submitted = true;
    if (this.estimationForm.invalid) {
      return;
    }
    const data = this.estimationForm.value;
    let total = data.GoldPrice * data.Weight;
    total -= (total * data.Discount) / 100;
    this.totalAmount = total;
  }

  printToScreen() {
    if (this.estimationForm.invalid) {
      return;
    }
    alert(`Total amount is: ${this.totalAmount}`);
  }

  printToFile() {
    if (this.estimationForm.invalid) {
      return;
    }
    const formData = this.estimationForm.value;
    var doc = new jsPDF();
    doc.setFontSize(16);
    let data = `Gold Price(per gram): ${formData.GoldPrice}\nWeight(per gram): ${formData.Weight}\n`;
    if (this.isDiscountVisible)
      data += `Discount: ${formData.Discount}%\n`;
    data += `Total Price: ${this.totalAmount}`;
    doc.text(data, 35, 25);
    doc.save("estimation.pdf");
  }

  printToPaper() {
    if (this.estimationForm.invalid) {
      return;
    }
    throw new Error("Not implemented");
  }
}
