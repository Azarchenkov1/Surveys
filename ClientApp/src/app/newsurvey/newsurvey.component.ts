import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router } from "@angular/router";

@Component({
  selector: 'app-newsurvey',
  templateUrl: './newsurvey.component.html',
  styleUrls: ['./newsurvey.component.css']
})
export class NewsurveyComponent{

  constructor(private http: HttpClient, private router: Router) { }

  submitData(form: NgForm)
  {
    var newsurvey = {
      CreatorName: form.value.creatorname,
      CreationDay: form.value.creationday,
      CreationMonth: form.value.creationmonth,
      CreationYear: form.value.creationyear,
      SurveyName: form.value.surveyname
    }
    let url = "http://localhost:4000/api/survey/survey";
    let data = JSON.stringify(newsurvey);
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    this.http.post(url,data,httpOptions).subscribe(response => { console.log(response)});

    this.router.navigate(["/"]);
  }
}