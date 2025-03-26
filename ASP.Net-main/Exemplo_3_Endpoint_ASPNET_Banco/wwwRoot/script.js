const API = "http://localhost:5000/Usuario";

document.getElementById("usuarioform").addEventListener("submit", salvarUsuario);
carregarUsuarios();

function carregarUsuarios() {
    fetch(API)
    .then(response => response.json())
    .then(data => {
        const tbody = document.querySelector("tabelaUsuarios tbody");
        tbody.innerHTML = "";
        data.forEach (usuario => {
            tbody.innerHTML += `
            <tr>
                <td>${usuario.id}</td>
                <td>${usuario.nome}</td>
                <td>${usuario.ramal}</td>
                <td>${usuario.espeialidade}</td>
                <td>
                    <button class="edit" onclick="editarusuario(${usuario.id})"></button>
                    <button class="delete" onclick='deletarUsuario(${usuario.id})'>Deletar</button>
                </td>
            </tr>
        `;
        })
    })
}