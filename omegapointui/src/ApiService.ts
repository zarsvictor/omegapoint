const basePath = "https://localhost:7133/api/person";

export const getPersonList = () => fetch(basePath).then((data) => data.json());

export const getPerson = (id) =>
    fetch(`${basePath}/${id}`, {
        method: "GET",
    }).then((response) => {
        console.log(response);
        return response.json();
    });

export const createPerson = (person) =>
    fetch(basePath, {
        method: "POST",
        body: JSON.stringify(person),
        headers: {
            "Content-Type": "application/json",
        }
    });

export const updatePerson = (id, person) =>
    fetch(`${basePath}/${id}`, {
        method: "PUT",
        body: JSON.stringify(person),
        headers: {
            "Content-Type": "application/json",
        }
    });

export const deletePerson = (id) =>
    fetch(`${basePath}/${id}`, {
        method: "DELETE",
    });