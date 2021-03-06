import Vue from 'vue'
import Router from 'vue-router'
import store from './../assets/js/store/store.js'

//DashBoards
import Administrador from '@/components/administrador/DashBoardAdministrador.vue'
import Aluno from '@/components/aluno/DashBoardAluno.vue'
import GerenteCadastro from '@/components/gerenteCadastro/DashBoardGerenteCadastro.vue'
import GerenteGeral from '@/components/gerenteGeral/DashBoardGerenteGeral.vue'
import Professor from '@/components/professor/DashBoardProfessor.vue'

//Compartilhado pelos Gerentes
import AlunosGeral from '@/components/gerentes/AlunosGeral.vue'
import ProfessoresGeral from '@/components/gerentes/ProfessoresGeral.vue'
import DisciplinasGeral from '@/components/gerentes/DisciplinasGeral.vue'
import GradesGeral from '@/components/gerentes/GradesGeral.vue'
import TurmasGeral from '@/components/gerentes/TurmasGeral.vue'
import AtrelarIdentificadoresGeral from '@/components/gerentes/AtrelarIdentificadoresGeral.vue'

//Compartilhado por todos os componentes
import Login from '@/components/geral/Login.vue'
import RedefinirSenha from '@/components/geral/RedefinirSenha.vue'
import EsqueciMinhaSenha from '@/components/geral/EsqueciMinhaSenha.vue'
import Home from '@/components/geral/Home.vue'
import MeusDados from '@/components/geral/MeusDados.vue'

// Aluno
import MinhasDisciplinasAluno from '@/components/aluno/MinhasDisciplinasAluno.vue'
import HistoricoCompletoAluno from '@/components/aluno/HistoricoCompletoAluno.vue'

//Professor
import MinhasDisciplinas from '@/components/professor/MinhasDisciplinas.vue'
import ListaManual from '@/components/professor/ListaManual.vue'
import HistoricoCompletoProfessor from '@/components/professor/HistoricoCompletoProfessor.vue'

//Gerente Geral
import Financeiro from '@/components/gerenteGeral/Financeiro.vue'
import Totens from '@/components/gerenteGeral/Totens.vue'
import GerentesGerais from '@/components/gerenteGeral/GerentesGerais.vue'
import GerentesCadastro from '@/components/gerenteGeral/GerentesCadastro.vue'

//Administrador
import AlunosADM from '@/components/administrador/AlunosADM.vue'
import DisciplinasADM from '@/components/administrador/DisciplinasADM.vue'
import GradesADM from '@/components/administrador/GradesADM.vue'
import PlanosADM from '@/components/administrador/PlanosADM.vue'
import FinanceiroADM from '@/components/administrador/FinanceiroADM.vue'
import InstituicoesADM from '@/components/administrador/InstituicoesADM.vue'
import ProfessoresADM from '@/components/administrador/ProfessoresADM.vue'
import GerentesCadastroADM from '@/components/administrador/GerentesCadastroADM.vue'
import GerentesGeraisADM from '@/components/administrador/GerentesGeraisADM.vue'
import TotensADM from '@/components/administrador/TotensADM.vue'
import AtrelarIdentificadoresADM from '@/components/administrador/AtrelarIdentificadoresADM.vue'
import TurmasADM from '@/components/administrador/TurmasADM.vue'


Vue.use(Router)

const rotas = new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/EsqueciMinhaSenha',
      name: 'EsqueciMinhaSenha',
      component: EsqueciMinhaSenha
    },
    {
      path: '/RedefinirSenha',
      name: 'RedefinirSenha',
      component: RedefinirSenha,
    },

    //Administrador
    {
      path: '/administrador',
      component: Administrador,
      children: [
        {
          path: 'Alunos',
          name: 'AlunosADM',
          component: AlunosADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Alunos' }]
          }
        },
        {
          path: 'Professores',
          name: 'ProfessoresADM',
          component: ProfessoresADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Professores' }]
          }
        },
        {
          path: 'GerentesCadastro',
          name: 'GerentesCadastroADM',
          component: GerentesCadastroADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Gerentes de Cadastro' }]
          }
        },
        {
          path: 'GerentesGerais',
          name: 'GerentesGeraisADM',
          component: GerentesGeraisADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Gerentes Gerais' }]
          }
        },
        {
          path: 'Disciplinas',
          name: 'DisciplinasADM',
          component: DisciplinasADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Disciplinas' }]
          }
        },
        {
          path: 'Grades',
          name: 'GradesADM',
          component: GradesADM,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Grades' }]
          }
        },
        {
          path: 'Turmas',
          name: 'TurmasADM',
          component: TurmasADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Turmas' }]
          }
        },
        {
          path: 'AtrelarIdentificadores',
          name: 'AtrelarIdentificadoresADM',
          component: AtrelarIdentificadoresADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Atrelar Identificadores' }]
          }
        },
        {
          path: 'Totens',
          name: 'TotensADM',
          component: TotensADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Totens' }]
          }
        },
        {
          path: 'Planos',
          name: 'PlanosADM',
          component: PlanosADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Planos' }]
          }
        },
        {
          path: 'Financeiro',
          name: 'FinanceiroADM',
          component: FinanceiroADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Financeiro' }]
          }
        },
        {
          path: 'Instituicoes',
          name: 'InstituicoesADM',
          component: InstituicoesADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Instituições' }]
          }
        },
        {
          path: 'MeusDados',
          name: 'MeusDadosAdministrador',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Meus Dados' }]
          }
        }
      ]
    },

    //Gerente Geral
    {
      path: '/gerentegeral',
      component: GerenteGeral,
      children: [
        {
          path: 'Alunos',
          name: 'GerenteGeralAlunos',
          component: AlunosGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Aluno' }]
          }
        },
        {
          path: 'Professores',
          name: 'GerenteGeralProfessores',
          component: ProfessoresGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Professores' }]
          }
        },
        {
          path: 'GerentesCadastro',
          name: 'GerenteGeralGerentesCadastro',
          component: GerentesCadastro,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Gerentes de Cadastro' }]
          }
        },
        {
          path: 'GerentesGerais',
          name: 'GerenteGeralGerentesGerais',
          component: GerentesGerais,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Gerentes Gerais' }]
          }
        },
        {
          path: 'Disciplinas',
          name: 'GerenteGeralDisciplinas',
          component: DisciplinasGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Disciplinas' }]
          }
        },
        {
          path: 'Grades',
          name: 'GerenteGeralGrades',
          component: GradesGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Grades' }]
          }
        },
        {
          path: 'Turmas',
          name: 'GerenteGeralTurmas',
          component: TurmasGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Turmas' }]
          }
        },
        {
          path: 'Totens',
          name: 'GerenteGeralTotens',
          component: Totens,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Totens' }]
          }
        },
        {
          path: 'AtrelarIdentificadores',
          name: 'GerenteGeralAtrelarIdentificadores',
          component: AtrelarIdentificadoresGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Atrelar Identificadores' }]
          }
        },
        {
          path: 'Financeiro',
          name: 'GerenteGeralFinanceiro',
          component: Financeiro,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Financeiro' }]
          }
        },
        {
          path: 'MeusDados',
          name: 'GerenteGeralMeusDados',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Meus Dados' }]
          }
        }
      ]

    },

    //Gerente Cadastro
    {
      path: '/gerentecadastro',
      component: GerenteCadastro,
      children: [
        {
          path: 'Alunos',
          name: 'GerenteCadastroAlunos',
          component: AlunosGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Alunos' },
            ]
          }
        },
        {
          path: 'Professores',
          name: 'GerenteCadastroProfessores',
          component: ProfessoresGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Professores' }]
          }
        },
        {
          path: 'Disciplinas',
          name: 'GerenteCadastroDisciplinas',
          component: DisciplinasGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Disciplinas' }]
          }
        },
        {
          path: 'Grades',
          name: 'GerenteCadastroGrades',
          component: GradesGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Grades' }]
          }
        },
        {
          path: 'AtrelarIdentificadores',
          name: 'GerenteCadastroAtrelarIdentificadores',
          component: AtrelarIdentificadoresGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Atrelar Identificadores' }]
          }
        },
        {
          path: 'Turmas',
          name: 'GerenteCadastroTurmas',
          component: TurmasGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Turmas' }]
          }
        },
        {
          path: 'MeusDados',
          name: 'GerenteCadastroMeusDados',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Meus Dados' }]
          }
        }


      ]

    },

    //Professor
    {
      path: '/professor',
      component: Professor,
      children: [
        {
          path: 'MinhasDisciplinas',
          name: 'MinhasDisciplinasProfessor',
          component: MinhasDisciplinas,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Minhas Disciplinas' }]
          }
        },
        {
          path: 'ListaManual',
          name: 'ListaManual',
          component: ListaManual,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Lista de Presença Manual' }]
          }
        },
        {
          path: 'HistoricoCompleto',
          name: 'HistoricoCompletoProfessor',
          component: HistoricoCompletoProfessor,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Histórico Completo' }]
          }
        },
        {
          path: 'MeusDados',
          name: 'MeusDadosProfessor',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Meus Dados' }]
          }
        }
      ]
    },

    //Aluno
    {
      path: '/aluno',
      component: Aluno,
      children: [
        {
          path: 'MinhasDisciplinasAluno',
          name: 'MinhasDisciplinasAluno',
          component: MinhasDisciplinasAluno,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
            { nome: 'Minhas Disciplinas' }]
          }
        },
        {
          path: 'HistoricoCompleto',
          name: 'HistoricoCompletoAluno',
          component: HistoricoCompletoAluno,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
            { nome: 'Histórico Completo' }]
          }
        },
        {
          path: 'MeusDados',
          name: 'MeusDadosAluno',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
            { nome: 'Meus Dados' }]
          }
        }
      ]
    },

    //Rota Padrão (404)
    {
      path: '*',
      component: Login
    },
  ]
})

function encaminhar(nivel, destino) {
  if (nivel == 6) {
    if (destino == "/REDEFINIRSENHA") {
      return true;
    } else {
      return "/redefinirSenha";
    };
  } else if (nivel == 5) {
    if (destino == "/ALUNO") {
      return true;
    } else {
      return "/aluno";
    };
  } else if (nivel == 4) {
    if (destino == "/PROFESSOR") {
      return true;
    } else {
      return "/professor";
    };
  } else if (nivel == 3) {
    if (destino == "/GERENTECADASTRO") {
      return true;
    } else {
      return "/gerenteCadastro";
    };
  } else if (nivel == 2) {
    if (destino == "/GERENTEGERAL") {
      return true;
    } else {
      return "/gerenteGeral";
    };
  } else if (nivel == 1) {
    if (destino == "/ADMINISTRADOR") {
      return true;
    } else {
      return "/administrador";
    };
  } else {
    return true;
  };
}

function getCookie(cname) {
  var name = cname + "=";
  var decodedCookie = decodeURIComponent(document.cookie);
  var ca = decodedCookie.split(";");
  for (var i = 0; i < ca.length; i++) {
    var c = ca[i];
    while (c.charAt(0) == " ") {
      c = c.substring(1);
    }
    if (c.indexOf(name) == 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "/";
}

rotas.beforeEach((to, from, next) => {
  var dest = to.matched[0].path.toUpperCase();

  if (dest != "/" && dest != "" && dest != "/LOGIN" && dest != "/ESQUECIMINHASENHA") {
    if (getCookie("Token") != "/") {
      store.commit("INSERIRTOKEN", getCookie("Token"));
      store.commit("INSERIRTIPOUSER", getCookie("TipoUser"));
      store.commit("CARREGARTOKEN");

      next(encaminhar(parseInt(getCookie("TipoUser")), to.matched[0].path.toUpperCase()));
    } else {

      if (from.matched.length != 0) {
        var reme = from.matched[0].path.toUpperCase();
        if (reme != "/" && reme != "" && reme != "/LOGIN" && reme != "/ESQUECIMINHASENHA") {
          store.commit("LOGOUT");
          swal({
            title: "Tempo Esgotado!",
            text: "A sua sessão de 30 minutos esgotou! Por favor, faça login novamente.",
            type: "info"
          });
        }
      }
      next("/Login");
    }
  } else {



    next(true);
  }


})

export default rotas;