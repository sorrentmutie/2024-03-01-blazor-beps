let myModal;
export function showModal(id) {
    myModal = new bootstrap.Modal(document.getElementById(id));
    myModal.show();
}

export function hideModal() {
    if (myModal !== null) {
        myModal.hide();
    }
}