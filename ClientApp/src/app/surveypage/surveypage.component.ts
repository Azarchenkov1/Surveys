import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-surveypage',
  templateUrl: './surveypage.component.html',
  styleUrls: ['./surveypage.component.css']
})
export class SurveypageComponent {

  surveyname = localStorage.getItem("SurveyName");
  creatorname = localStorage.getItem("CreatorName");
  CreationDay = parseInt(localStorage.getItem("CreationDay"));
  CreationMonth = parseInt(localStorage.getItem("CreationMonth"));
  CreationYear = parseInt(localStorage.getItem("CreationYear"));

  public questionlist = [];

  constructor(private http: HttpClient) { 
    let id = localStorage.getItem("id");
    let url = "http://localhost:4000/api/question/questions/" + id;
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    this.http.get<QuestionContract[]>(url,httpOptions).subscribe(response => { this.questionlist = response;
    console.log(this.questionlist) });
   }
}
