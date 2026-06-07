import { useEffect, useState } from 'react'
import { type IPerson } from './models/IPerson'
import './App.css'
import PersonList from './components/PersonList';
import { createPerson, deletePerson, getPerson, getPersonList, updatePerson } from './ApiService';

function App() {
    const [id, setId] = useState<number>(0);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [age, setAge] = useState(0);
    const [people, setPeople] = useState<IPerson[]>([]);

    const handleGet = (e) => {
        e.preventDefault();
        getPerson(id).then((response: IPerson) => {
            setFirstName(response.firstName);
            setLastName(response.lastName);
            setAge(response.age);
        });
    };
    const handleCreate = (e) => {
        e.preventDefault();
        createPerson({
            firstName: firstName,
            lastName: lastName,
            age: age,
        });
    };
    const handleUpdate = (e) => {
        e.preventDefault();
        updatePerson(id, {
            firstName: firstName,
            lastName: lastName,
            age: age,
        });
    };
    const handleDelete = (e) => {
        e.preventDefault();
        deletePerson(id);
    };

    useEffect(() => {
        getPersonList()
            .then((result: IPerson[]) => {
                console.log(result);
                setPeople(result);
            })
    }, [])

    return (
        <>
            <form>
                <label>
                    Id:
                    <input type="number" name="Id" value={id} onChange={e => setId(Number(e.target.value))} />
                </label>
                <br />
                <label>
                    First name:
                    <input type="text" name="FirstName" value={firstName} onChange={e => setFirstName(e.target.value) } />
                </label>
                <br />
                <label>
                    Last name:
                    <input type="text" name="LastName" value={lastName} onChange={e => setLastName(e.target.value)} />
                </label>
                <br />
                <label>
                    Age:
                    <input type="number" name="age" value={age} onChange={e => setAge(Number(e.target.value))} />
                </label>
                <br />
                <button onClick={handleGet}>Get</button>
                <button onClick={handleCreate}>Create</button>
                <button onClick={handleUpdate}>Update</button>
                <button onClick={handleDelete}>Delete</button>
            </form>
            <PersonList people={people}/>
        </>
  )
}

export default App
