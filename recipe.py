import yaml

class ResumeRecipeSection:
    def __init__(self) -> None:
        self._include_subsections = None
        self._exclude_subsections = None
        self._include_tags = None
        self._exclude_tags = None

    def include_subsection(self, subsection_key: str):
        self._append_list("_include_subsections", subsection_key)

    def exclude_subsection(self, subsection_key: str):
        self._append_list("_exclude_subsections", subsection_key)

    def include_tag(self, tag: str):
        self._append_list("_include_tags", tag)

    def exclude_tag(self, tag: str):
        self._append_list("_exclude_tags", tag)

    def add_tags_wildcard(self):
        self._include_tags = []

    def includes_subsection(self, subsection: str, globally_included: bool):
        return self._includes(subsection, self._include_subsections, self._exclude_subsections, globally_included)

    def includes_tag(self, tag: str, globally_included: bool):
        return self._includes(tag, self._include_tags, self._exclude_tags, globally_included)

    def _append_list(self, list_var_name: str, item: str):
        if getattr(self,list_var_name) is None:
            setattr(self,list_var_name, [])

        getattr(self, list_var_name).append(item)

    def _includes(self, item: str, include_list: list[str], exclude_list: list[str], globally_included: bool):
        included = self._list_includes(include_list, item, globally_included)
        excluded = self._list_includes(exclude_list, item, not globally_included)
        return included and not excluded

    def _list_includes(self, item_list, item, globally_included: bool):
        if item_list is list:
            return len(item_list) == 0 or item in item_list

        return globally_included
class ResumeRecipe:
    negation_char = "~"
    wildcard_char = "*"

    def __init__(self, path=None) -> None:
        self.include_tags = []
        self.exclude_tags = []
        self.include_sections = {}
        self.exclude_sections = []

        if path is not None:
            self.parse_from_file(path)

    def is_negation(s: str):
        return s.startswith(ResumeRecipe.negation_char)

    def is_wildcard(s: str):
        return s == ResumeRecipe.wildcard_char

    def parse_from_file(self, path: str):
        with open(path, "r", encoding="utf8") as f:
            recipe = yaml.safe_load(f)

            # Parse tags
            for tag in recipe["Tags"]:
                if ResumeRecipe.is_negation(tag):
                    self.exclude_tags.append(tag)
                else:
                    self.include_tags.append(tag)

            # Parse sections
            for key, filter in recipe["Sections"]:
                if ResumeRecipe.is_negation(key):
                    self.exclude_sections.append(key)
                else:
                    # Create the default section information
                    section = ResumeRecipeSection()

                    # If it's not wildcard, parse the section
                    if not ResumeRecipe.is_wildcard(key):
                        # Parse subsections
                        if "Subsections" in filter:
                            subsections = filter["Subsections"]
                            if not ResumeRecipe.is_wildcard(subsections):
                                for subsection in subsections:
                                    if ResumeRecipe.is_negation(subsection):
                                        section.exclude_subsection(subsection)
                                    else:
                                        section.include_subsection(subsection)

                        # Parse tags
                        if "Tags" in filter:
                            tags = filter["Tags"]
                            if ResumeRecipe.is_wildcard(tags):
                                section.add_tags_wildcard()
                            else:
                                for tag in tags:
                                    if ResumeRecipe.is_negation(tag):
                                        section.exclude_tag(tag)
                                    else:
                                        section.include_tag(tag)

                    self.include_sections[key] = section

    def includes(self, section: str, subsection: str, tags: list[str]):
        tags_included = True
        if 
