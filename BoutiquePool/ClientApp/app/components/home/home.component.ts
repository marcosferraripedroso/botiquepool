import { Component  } from '@angular/core';
import { Http, Response } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public currentTotal = '';

    constructor(private http: Http)
    {
        http.get('http://localhost:49596/home/GetCount').subscribe(data => {
            this.currentTotal = JSON.parse(JSON.stringify(data))._body;
        });
                
    }
}
