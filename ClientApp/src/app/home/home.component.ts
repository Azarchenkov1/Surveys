import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public surveylist = [];

  constructor(private http: HttpClient) {
    let url = "http://localhost:4000/api/survey/surveys";
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    this.http.get<SurveyContract[]>(url,httpOptions).subscribe(response => { this.surveylist = response;
    console.log(this.surveylist) });
  }
}
