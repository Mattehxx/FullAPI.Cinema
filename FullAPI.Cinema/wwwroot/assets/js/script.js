document.addEventListener('DOMContentLoaded', () => {
    fetch('http://localhost:8075/api/Employee')
    .then(response => {
        if(!response.ok)
            throw new Error('Errore');
    
        response.json().then(json => {
            json.forEach(element => {
                let completeElement = `<p>Name: ${element.name}</p> <p>Surname: ${element.surname}</p>`
                document.querySelector('#employee-container').innerHTML += completeElement; 
            });
        });
    });
});