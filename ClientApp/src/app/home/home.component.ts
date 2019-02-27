import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public surveylist = [];

  constructor(private http: HttpClient, private router: Router) {
    let url = "http://localhost:4000/api/survey/surveys";
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    this.http.get<SurveyContract[]>(url,httpOptions).subscribe(response => { this.surveylist = response;
    console.log(this.surveylist) });
  }

  GoToSurveyPage(event)
  {
    var targetobject = event.target;
    var idattribute = targetobject.attributes.id;
    var id = idattribute.nodeValue;
    console.log('target element have id ' + id);
    localStorage.setItem("id", id);

    this.surveylist.forEach(function (survey) { 
      if(survey.surveyId == id) 
      { 
        localStorage.setItem("SurveyName", survey.surveyName);
        localStorage.setItem("CreatorName", survey.creatorName);
        localStorage.setItem("CreationDay", survey.creationDay);
        localStorage.setItem("CreationMonth", survey.creationMonth);
        localStorage.setItem("CreationYear", survey.creationYear);
      }
    });

    this.router.navigate(["/surveypage"]);
  }
}
