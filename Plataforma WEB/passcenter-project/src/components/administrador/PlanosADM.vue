<template>
  <div class="row area-exibicao">
    <form class="col s12 card data2" onsubmit="return false">
      <div class="row topo">
        <div class="col s12 m12 l12">
          <h3 class="col s12 m12 l12 centro">Listar Planos</h3>

          <table>
            <thead class="centro">
              <tr>
                <th>Nome da Instituição</th>
                <th>Qtd. Tags</th>
                <th>Qtd. Totens</th>
                <th>Valor por TAG</th>
                <th>Valor por Totem</th>
                <th>Valor total</th>
                <th>Ação</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in planos" :key="item.id">
                <td>{{ item.ins_nome_fantasia}}</td>
                <td>{{ item.pla_qtd_tags }}</td>
                <td>{{ item.pla_qtd_totens }}</td>
                <td>{{ "R$ "+item.pla_preco_tags }}</td>
                <td>{{ "R$ "+item.pla_preco_totens }}</td>
                <td>{{ "R$ "+((item.pla_qtd_tags * item.pla_preco_tags) + (item.pla_qtd_totens * item.pla_preco_totens)) }}</td>
                <td v-if="item.pla_estado">
                  <a class="waves-effect waves-light btn disabled">Ativo</a>
                </td>
                <td v-else>
                  <a
                    class="waves-effect waves-light btn green"
                    @click="confirmacaoUpdate(item.pla_codigo,  item.ins_codigo)"
                  >Ativar</a>
                </td>
              </tr>
            </tbody>
          </table>

          <a
            class="col s12 m12 l12 centro waves-effect waves-light btn modal-trigger botaoVerMais"
            href="#modalAdd"
            @click="addDados()"
          >Adicionar plano</a>

          <div id="modalAdd" class="modal margem">
            <div class="modal-content">
              <h4 class="centro">Cadastro Plano</h4>
              <hr>

              <div class="row">
                <div class="col s12 m12 l12">
                  <div class="input-field col s12 m4">
                    <select v-model="instituicao">
                      <option value disabled selected>Selecione a Instituição</option>
                      <option
                        :value="item.ins_codigo"
                        v-for="item in instituicoes"
                        :key="item.id"
                      >{{ item.ins_nome_fantasia }}</option>
                    </select>
                    <label>Instituição</label>
                  </div>

                  <div class="input-field col s12 m4">
                    <input id="qtdTags" type="number" min="0" class="validate" v-model="qtdTags">
                    <label for="qtdTags">Qtd. TAGs:</label>
                  </div>

                  <div class="input-field col s12 m4">
                    <input
                      id="qtdTotens"
                      type="number"
                      min="0"
                      class="validate"
                      v-model="qtdTotens"
                    >
                    <label for="qtdTotens">Qtd. Totens:</label>
                  </div>
                </div>
              </div>

              <div class="row">
                <div class="col s12 m12 l12">
                  <div class="input-field col s12 m4">
                    <select v-model="estado">
                      <option value disabled selected>Selecione o Estado</option>
                      <option value="true">Ativo</option>
                      <option value="false">Inativo</option>
                    </select>
                    <label>Estado</label>
                  </div>

                  <div class="input-field col s12 m4">
                    <input id="precoTags" type="text" class="validate" v-model="precoTags">
                    <label for="precoTags">PreçoTAGs:</label>
                  </div>

                  <div class="input-field col s12 m4">
                    <input id="precoTotens" type="text" class="validate" v-model="precoTotens">
                    <label for="precoTotens">Preço Totens:</label>
                  </div>
                </div>
              </div>
            </div>

            <div class="modal-footer row col s12 m12 l12">
              <a class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
              <p class="col s12 m4 l4"></p>
              <a
                class="col s12 m4 l4 waves-effect waves-teal btn green"
                @click="confirmacaoCriar()"
              >Confirmar</a>
            </div>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "planos",
  data() {
    return {
      planos: [],
      instituicoes: [],
      instituicao: 0,
      estado: false,
      qtdTags: 0,
      qtdTotens: 0,
      precoTotens: 0.0,
      precoTags: 0.0
    };
  },

  mounted() {
    $(document).ready(function() {
      $(".modal").modal();
      M.updateTextFields();
      $("select").formSelect();
    });

    this.carregarDados();

    this.$http.get("Instituicoes").then(
      response => {
        this.instituicoes = response.body;
      },
      response => {
        this.erro("Instituições", response.status);
      }
    );
  },
  methods: {
    carregarDados() {
      this.$http.get("Planos").then(
        response => {
          this.planos = response.body;
        },
        response => {
          this.erro("Planos", response.status);
        }
      );
    },

    addDados() {
      this.instituicao = 0;
      this.estado = false;
      this.qtdTags = 0;
      this.qtdTotens = 0;
      this.precoTotens = 0.0;
      this.precoTags = 0.0;

      $(document).ready(function() {
        M.updateTextFields();
        $("select").formSelect();
      });
    },

    confirmacaoUpdate(codigo, instituicao) {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Você tem certeza?",
        text: "Você não poderá reverter essa ação!",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, faça!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          const dadosPlanos = {
            pla_codigo: codigo,
            ins_codigo: {
              ins_codigo: instituicao
            }
          };

          this.$http.put("Planos", dadosPlanos).then(
            response => {
              this.carregarDados();
              swalWithBootstrapButtons(
                "Alterado!",
                "As alterações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("Planos", response.status);
            }
          );
        } else if (
          // Read more about handling dismissals
          result.dismiss === swal.DismissReason.cancel
        ) {
          this.carregarDados();
          swalWithBootstrapButtons(
            "Cancelado!",
            "Alterações não enviadas!",
            "error"
          );
        }
      });
    },

    confirmacaoCriar() {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Todos os dados estão corretos?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, Crie!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          const dadosPlanos = {
            pla_qtd_tags: this.qtdTags,
            pla_qtd_totens: this.qtdTotens,
            pla_preco_tags: this.precoTags,
            pla_preco_totens: this.precoTotens,
            pla_estado: this.estado,
            ins_codigo: {
              ins_codigo: this.instituicao
            }
          };

          this.$http.post("planos", dadosPlanos).then(
            response => {
              this.carregarDados();
              swalWithBootstrapButtons(
                "Salvo!",
                "Todas as informações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("Dados da plano", response.status);
            }
          );
        } else if (
          // Read more about handling dismissals
          result.dismiss === swal.DismissReason.cancel
        ) {
          this.carregarDados(),
            swalWithBootstrapButtons(
              "Okay!",
              "Revise/altere o que for necessário ;)",
              "info"
            );
        }
      });
    },

    erro(msg, code) {
      swal({
        title: "Oops!",
        text: "Algo deu errado! Entre em contato com os Administradores!",
        type: "error"
      }),
        console.log(
          "ERRO em " + msg + "! Código de resposta (HTTP) do servidor: " + code
        );
    }
  }
};
</script>

<style src="./../../assets/css/gerenteGeral/Financeiro.css" scoped></style>
<style src="./../../assets/css/gerenteGeral/tables.css" scoped></style>
   
