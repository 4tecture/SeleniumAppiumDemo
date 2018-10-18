import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public result: number;

  public add (a: number, b: number) {
    this.result = +a + +b;
  }

  public subtract (a: number, b: number) {
    this.result = +a - +b;
  }

  public multiply (a: number, b: number) {
    this.result = +a * +b;
  }

  public divide (a: number, b: number) {
    this.result = +a / +b;
  }

  public clear (a: any, b: any) {
    this.result = null;
  }

}
