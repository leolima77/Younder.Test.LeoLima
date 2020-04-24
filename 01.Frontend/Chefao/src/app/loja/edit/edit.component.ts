import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {first} from "rxjs/operators";
import {Loja} from "../../model/loja.model";
import {ApiService} from "../../service/api.service";

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  loja: Loja;
  editForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private router: Router, private apiService: ApiService) { }

  ngOnInit() {
    let idLoja = window.localStorage.getItem("idLojaEdit");
    if(!idLoja) {
      alert("ação Inválida.")
      this.router.navigate(['loja/list']);
      return;
    }
    this.editForm = this.formBuilder.group({
      idLoja: [],
      nomeFantasia: ['', Validators.required],
      descricao: ['', Validators.required],
      tags: ['', Validators.required],
      email: ['', Validators.required],
      telefone: ['', Validators.required],
      dominio: ['', Validators.required],
      ativa: ['', Validators.required]
    });
    this.apiService.getLojaById(+idLoja)
      .subscribe( data => {
        //debugger;
        this.editForm.setValue(data);
      });
  }

  onSubmit() {
    this.apiService.updateLoja(this.editForm.value)
      .pipe(first())
      .subscribe(
        data => {
          //debugger;
          if(data !== undefined) {
            alert('Loja atualizada com sucesso.');
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
