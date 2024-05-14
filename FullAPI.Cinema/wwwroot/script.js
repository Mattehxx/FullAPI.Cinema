document.addEventListener('DOMContentLoaded', () => {
    fetch('http://localhost:8075/api/Employee')
    .then(response => {
        if(!response.ok)
            throw new Error('Errore');
    
        response.json(json => {
            document.querySelector('#employee-container').textContent = json;
        })
    });
});