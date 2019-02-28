import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router } from "@angular/router";

@Component({
  selector: 'app-newquestion',
  templateUrl: './newquestion.component.html',
  styleUrls: ['./newquestion.component.css']
})
export class NewquestionComponent {

  constructor(private http: HttpClient, private router: Router) { }

  submitData(form: NgForm)
  {
    var newquestion = {
      SurveyId: localStorage.getItem("id"),
      QuestionDescription: form.value.question,
      AdditionalInformation: form.value.information,
      Answer1: form.value.answer1,
      Answer2: form.value.answer2,
      Answer3: form.value.answer3,
    }

    let url = "http://localhost:4000/api/question/question";
    let data = JSON.stringify(newquestion);
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    this.http.post(url,data,httpOptions).subscribe(response => { console.log(response)});

    this.router.navigate(["/"]);
  }
}
