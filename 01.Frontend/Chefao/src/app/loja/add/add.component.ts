import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {ApiService} from "../../service/api.service";
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,private router: Router, private apiService: ApiService) { }

  addForm: FormGroup;

  ngOnInit() {
    this.addForm = this.formBuilder.group({
      idLoja: 0,
      nomeFantasia: ['', Validators.required],
      descricao: ['', Validators.required],
      tags: ['', Validators.required],
      email: ['', Validators.required],
      telefone: ['', Validators.required],
      dominio: ['', Validators.required],
      ativa: ['', Validators.required]
    });

  }

  onSubmit() {
    this.apiService.createLoja(this.addForm.value)
    .pipe(first())
    .subscribe(
      data => {
        //debugger;
        if(data !== undefined) {
          alert('Loja incluída com sucesso.');
          this.router.navigate(['loja/list']);
        }else {
          alert("Alguma coisa deu errado");
        }
      },
      error => {
        alert(error);
      });
  }

}
