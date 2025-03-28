const API = "http://localhost:5000/Usuario";

document.getElementById("usuarioform").addEventListener("submit", salvarUsuario);
carregarUsuarios();

function carregarUsuarios() {
    fetch(API)
        .then(response => response.json())
        .then(data => {
            const tbody = document.querySelector("#tabelaUsuarios tbody");
            tbody.innerHTML = "";
            data.forEach(usuario => {
                tbody.innerHTML += `
                    <tr>
                        <td>${usuario.id}</td>
                        <td>${usuario.nome_usuario || usuario.nome}</td>
                        <td>${usuario.ramal}</td>
                        <td>${usuario.especialidade}</td>
                        <td>
                            <button class="edit" onclick="editarUsuario(${usuario.id})">Editar</button>
                            <button class="delete" onclick="deletarUsuario(${usuario.id})">Deletar</button>
                        </td>
                    </tr>
                `;
            });
        })
        .catch(error => console.error('Erro ao carregar usuários:', error));
}

function salvarUsuario(event) {
    event.preventDefault();
    const id = document.getElementById("id").value;
    const usuario = {
        id: parseInt(id || 0),
        nome_usuario: document.getElementById("nome").value, // ou nome, conforme o esperado pelo servidor
        password: document.getElementById("password").value,
        ramal: document.getElementById("ramal").value,
        especialidade: document.getElementById("especialidade").value
    };

    const metodo = id ? "PUT" : "POST";
    const url = id ? `${API}/${id}` : API;

    fetch(url, {
        method: metodo,
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(usuario)
    })
        .then(res => {
            if (!res.ok) {
                throw new Error('Erro na requisição');
            }
            return res.json();
        })
        .then(() => {
            document.getElementById("usuarioform").reset(); // Corrigido de requestFullscreen para reset
            carregarUsuarios();
        })
        .catch(error => console.error('Erro ao salvar usuário:', error));
}

function editarUsuario(id) {
    console.log("Tentando editar ID:", id);
    console.log("URL completa:", `${API}/${id}`);

    fetch(`${API}/${id}`)
        .then(response => {
            console.log("Resposta bruta:", response);
            if (!response.ok) {
                return response.text().then(text => {
                    console.error("Conteúdo do erro:", text);
                    throw new Error(text);
                });
            }
            return response.json();
        })
        .then(usuario => {
            console.log("Dados recebidos:", usuario);
            document.getElementById("id").value = usuario.id;
            document.getElementById("nome").value = usuario.nome_usuario || usuario.nome;
            document.getElementById("password").value = usuario.password;
            document.getElementById("ramal").value = usuario.ramal;
            document.getElementById("especialidade").value = usuario.especialidade;
        })
        .catch(error => {
            console.error("Erro completo:", error);
            alert("Erro completo no console");
        });
}
function deletarUsuario(id) {
    if (!confirm('Tem certeza que deseja deletar este usuário?')) {
        return;
    }

    fetch(`${API}/${id}`, {
        method: 'DELETE'
    })
        .then(res => {
            if (!res.ok) {
                throw new Error('Erro ao deletar usuário');
            }
        })
        .then(() => carregarUsuarios())
        .catch(error => console.error('Erro ao deletar usuário:', error));
}