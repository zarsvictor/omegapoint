import type { IPerson } from "../models/IPerson";


function PersonList({ people }: { people: IPerson[] }) {
    return (
        <>
            <table>
                <caption>
                    All persons
                </caption>
                <thead>
                    <tr>
                        <th scope="col">Id</th>
                        <th scope="col">First name</th>
                        <th scope="col">Last name</th>
                        <th scope="col">Age</th>
                    </tr>
                </thead>
                <tbody>
                    {people.map(person =>
                        <tr key={person.id}>
                            <td>{person.id}</td>
                            <td>{person.firstName}</td>
                            <td>{person.lastName}</td>
                            <td>{person.age}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </>
  );
}

export default PersonList;