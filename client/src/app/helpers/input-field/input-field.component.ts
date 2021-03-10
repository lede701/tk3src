import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'tk3-input-field',
  templateUrl: './input-field.component.html',
  styleUrls: ['./input-field.component.less']
})
export class InputFieldComponent implements ControlValueAccessor {

  @Input() type: string = 'text';
  @Input() label: string = 'Label';

  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
  }

  writeValue(obj: any): void {
  }

  registerOnChange(fn: any): void {
  }

  registerOnTouched(fn: any): void {
  }


}
