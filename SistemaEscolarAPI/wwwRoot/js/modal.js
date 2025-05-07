class CustomModal {
    constructor() {
        this.modal = document.getElementById('div');
        this.modal.className = 'modal';
        this.modal.innerHTML = `
            <div class="modal-content">
                <div class="modal-title">
                    <h3 class="modal-title">Pessoas Responsaveis</h3>
                    <button class="modal-close">&times;</button>
                </div>
                <div class="modal-body"></div>
                <div class="modal-footer"></div>
        `;
        document.body.appendChild(this.modal);

        this.modal.querySelector('.modal-close').addEventListener('click', () =>this.hide());
    }
    show(title, body, buttons = []) {
        this.modal.querySelector('.modal-title').textContent = title;
        this.modal.querySelector('.modal-body').innerHTML = body;

        const footer = this.modal.querySelector(".modal-footer");
        footer.innerHTML = "";

        buttons.forEach(btn => {
            const button = document.createElement('button');
            button.className `btn btn-${btn.type || 'secondary'}`;
            button.textContent = btn.text;
            button.addEventListener ('click', () => {
                if (btn.handler) btn.handler();
                if (btn.close !== false) this.hide();
            });
            this.modal.classList.add('active');
            document.body.style.overflow = 'hidden';
        })

    }
    hide() {
        this.modal.classList.remove('active');
        document.body.style.overflow = ''; 
    } 
}